﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SharedLibrary;

namespace ChatServiceLibrary
{
    /// <summary>
    /// ChatServiceLibrary
    /// Implements the IChatService
    /// Runs as a singleton "one instance"
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {

        #region Fields

        // Set to a small number for testing purposes
        private const int maximumMessages = 40;

        // The Message History is a Queue
        private Queue<ChatMessage> chatMessages = new Queue<ChatMessage>();

        // The list of logged in users plus their callback information
        private Dictionary<string, IChatServiceCallback> loggedInUsers = new Dictionary<string, IChatServiceCallback>();

        #endregion Fields

        #region IChatService Implementation

        /// <summary>
        /// GetMessageHistory()
        /// Returns a list of the most recent chat messages
        /// </summary>
        /// <returns>a list of all the chat messages List<ChatMessage></returns>
        public List<ChatMessage> GetMessageHistory()
        {
            return chatMessages.ToList();
        }

        /// <summary>
        /// Login
        /// Logins the user and registers the callback into a dictionary of
        /// logged in users.
        /// Sends a messgae that the user has logged on...
        /// </summary>
        /// <param name="userName">user name from the client (string)</param>
        public void Login(string userName)
        {
            // Trim the Username to 15 Characters
            if (userName.Length > 15)
            {
                userName = userName.Substring(0, 15);
            }

            // This is the caller and registers the callback for the service to 
            // communicate the new messages
            IChatServiceCallback callback = OperationContext.Current.GetCallbackChannel<IChatServiceCallback>();

            // Validates the User is Not Already Logged In
            if (!loggedInUsers.ContainsKey(userName))
            {
                // Add to the List of Logged on Users
                loggedInUsers.Add(userName, callback);

                // Send a Message that the new user is Logged In
                SendMessage("Admin", $"User {userName} logged in...");

                // Write to Console
                Console.WriteLine($"User {userName} logged in...");

            } // end of if

            // Duplicate User Fault - User Logged In Already
            else
            {
                DuplicateUserFault fault = new DuplicateUserFault()
                { Reason = "User '" + userName + "' already logged in!" };
                throw new FaultException<DuplicateUserFault>(fault);
            } // end of else

        } // end of method

        /// <summary>
        /// LogInState
        /// Returns the login state of a user
        /// </summary>
        /// <param name="userName">user name from the client (string)</param>
        /// <returns>true if user is logged in, false otherwise</returns>
        public bool LogInState(string userName)
        {
            // Trim the Username to 15 Characters
            if (userName.Length > 15)
            {
                userName = userName.Substring(0, 15);
            }

            if (loggedInUsers.ContainsKey(userName))
            {
                return true;
            }
            else
            {
                return false;
            }
        } // end of  method

        /// <summary>
        /// Logoff
        /// Logs off the user by removing the user from the logged in user list
        /// Send a message that the user has logged off..
        /// </summary>
        /// <param name="userName">user name from the client (string)</param>
        public void Logoff(string userName)
        {
            // Trim the Username to 15 Characters
            if (userName.Length > 15)
            {
                userName = userName.Substring(0, 15);
            }

            try
            {
                if (loggedInUsers.ContainsKey(userName))
                {
                    // Remove from the List of Logged on Users
                    loggedInUsers.Remove(userName);

                    // Send a Message that the user is Logged Off
                    SendMessage("Admin", $"User {userName} logged off...");

                    // Send Message to Console
                    Console.WriteLine($"User {userName} logged off...");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        } // end of method

        /// <summary>
        /// SendMessage
        /// The Service Implementation that handles the client request
        /// to send it a message
        /// </summary>
        /// <param name="userName">user name from the client (string)</param>
        /// <param name="message">the message (string) from the client</param>
        public void SendMessage(string userName, string message)
        {
            // Trim the Username to 15 Characters
            if (userName.Length > 15)
            {
                userName = userName.Substring(0, 15);
            }

            try
            {
                // Verify the User is Logged On First
                if (userName != "Admin" && !loggedInUsers.ContainsKey(userName))
                {
                    // Try to Login User First
                    Login(userName);
                }

                // Create New Message Object
                ChatMessage chatmessage = new ChatMessage(userName, DateTime.Now , message);

                // Add to Message History
                AddMessage(chatmessage);

                // Transmitt to Connected Users
                SendMessageToUsers(chatmessage);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        } // end of method

        #endregion IChatService Implementation

        #region Methods

        /// <summary>
        /// AddMessage
        /// Add to Chat Messages
        /// </summary>
        /// <param name="message">the message object (ChatMessage) to add to the queue collection</param>
        private void AddMessage(ChatMessage message)
        {
            // There is a Message Limit
            // Dequeue then Enqueue
            if (chatMessages?.Count >= maximumMessages)
            {
                chatMessages.Dequeue();
                chatMessages.Enqueue(message);
            }
            // Enqueue
            else
            {
                chatMessages?.Enqueue(message);
            }
        } // end of method

        /// <summary>
        /// SendMessageToUsers
        /// Transmit to Registered Users & Callbacks
        /// Logs off any disconnected clients
        /// </summary>
        /// <param name="message">The message to send to all clients (ChatMessage)</param>
        private void SendMessageToUsers(ChatMessage message)
        {
            // Inform all of the clients of the new message
            List<string> callbackKeys = loggedInUsers?.Keys.ToList();

            // Loops through each logged in user
            foreach (string key in callbackKeys)
            {
                try
                {
                    IChatServiceCallback callback = loggedInUsers[key];
                    callback.SendClientMessage(message);
                    Console.WriteLine($"Sending user {key} message {message}");
                }
                // catches an issue with a user disconnect and loggs off that user
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    // Remove the disconnected client
                    Logoff(key);
                }
            } // end of foreach
        } // end of method

        #endregion Methods

    } // end of class
} // end of namespace

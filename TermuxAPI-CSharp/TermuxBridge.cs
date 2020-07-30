
using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TermuxAPICSharp.API;

namespace TermuxAPICSharp
{
    public static class TermuxBridge
    {
        /// <summary>
        /// Execute the specified command. This method can throw an exception.
        /// </summary>
        /// <returns>The command's standard output.</returns>
        /// <param name="command">Command.</param>
        public static string Execute(string command, string args)
        {
            command = command.Replace("\"", "\"\"");

            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine("/data/data/com.termux/files/usr/bin", command),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            if (!string.IsNullOrEmpty(args))
                process.StartInfo.Arguments = args;

            process.Start();
            process.WaitForExit();

            return process.StandardOutput.ReadToEnd();
        }

        /// <summary>
        /// Tries to execute the specified command.
        /// </summary>
        /// <returns><c>true</c>, if the command executed, <c>false</c> otherwise.</returns>
        /// <param name="command">Command.</param>
        /// <param name="output">The parsed JSON token.</param>
        public static bool TryExecute(string command, string args, out string output)
        {
            try
            {
                output = Execute(command, args);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                output = null;
                return false;
            }
        }

        /// <summary>
        /// Executes the specified command. This method can throw an exception.
        /// </summary>
        /// <returns>The parsed JSON token.</returns>
        /// <param name="command">Command.</param>
        public static JToken ExecuteJson(string command, string args)
        {
            return JToken.Parse(Execute(command, args));
        }

        /// <summary>
        /// Tries to execute the specified command.
        /// </summary>
        /// <returns><c>true</c>, if the command executed and returned valid JSON, <c>false</c> otherwise.</returns>
        /// <param name="command">Command.</param>
        /// <param name="jtoken">The parsed JSON token.</param>
        public static bool TryExecuteJson(string command, string args, out JToken jtoken)
        {
            try
            {
                jtoken = ExecuteJson(command, args);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                jtoken = null;
                return false;
            }
        }

        /// <summary>
        /// Executes the specified command. This method can throw an exception.
        /// </summary>
        /// <returns>JSON data mapped to an object of the specified type.</returns>
        /// <param name="command">Command.</param>
        public static T ExecuteObject<T>(string command, string args) where T : class
        {
            return JsonConvert.DeserializeObject<T>(Execute(command, args));
        }

        /// <summary>
        /// Tries to execute the specified command. This method will only throw an exception upon encountering a TermuxAPIError instance.
        /// </summary>
        /// <returns><c>true</c>, if the command executed, returned valid JSON and was successfully mapped to the specified type, <c>false</c> otherwise.</returns>
        /// <param name="command">Command.</param>
        /// <param name="output">Object the data should be mapped to.</param>
        public static bool TryExecuteObject<T>(string command, string args, out T output) where T : class
        {
            try
            {
                output = ExecuteObject<T>(command, args);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // If the output type is not TermuxAPIError (prevent an infinite loop)
                if(!typeof(TermuxAPIError).IsAssignableFrom(typeof(T)))
                {
                    // Check if the JSON data is an API error
                    if(TryExecuteObject(command, args, out TermuxAPIError error))
                    {
                        Console.WriteLine("The Termux API has returned an error: " + error.Message);
                    }
                }
                output = null;
                return false;
            }
        }
    }
}

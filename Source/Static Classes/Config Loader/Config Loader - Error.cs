﻿/*ISC License

Copyright(c) 2019, Daan Verstraten, daanverstraten@hotmail.com

Permission to use, copy, modify, and/or distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies.


THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
MERCHANTABILITY AND FITNESS.IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.*/
using System;
using System.IO;
using System.Text;

namespace DaanV2.Config
{
    public static partial class ConfigLoader
    {
        /// <summary>Handles and writes the appropriate message </summary>
        /// <param name="Filepath">The filepath to the config file</param>
        /// <param name="ex">The exception that has been throw</param>
        private static void ErrorLoading(String Filepath, Exception ex)
        {
            String ErrorPath = Filepath + DateTime.Now.ToString() + ".corrupt";
            var MessageBuilder = new StringBuilder(2000);
            MessageBuilder.AppendLine("ConfigHandling.Loader: ");

            while (ex != null)
            {
                MessageBuilder.AppendLine(ex.Message);
                MessageBuilder.AppendLine("\r\n\r\n");
                MessageBuilder.AppendLine(ex.StackTrace);
                MessageBuilder.AppendLine("\r\n\r\n");

                ex = ex.InnerException;
            }

            String Message = MessageBuilder.ToString();

            if (File.Exists(ErrorPath))
            {
                File.Delete(ErrorPath);
            }

            File.Move(Filepath, ErrorPath);
            File.WriteAllText(ErrorPath + ".txt", Message);
            File.Delete(Filepath);

            System.Diagnostics.Debug.WriteLine(Message);
        }

        /// <summary>Handles and writes the appropriate message </summary>
        /// <param name="Filepath">The filepath to the config file</param>
        /// <param name="ex">The exception that has been throw</param>
        private static void ErrorSaving(String Filepath, Exception ex)
        {
            String ErrorPath = Filepath + DateTime.Now.ToString() + ".corrupt";
            var MessageBuilder = new StringBuilder(2000);
            MessageBuilder.AppendLine("ConfigHandling.Saver: ");

            while (ex != null)
            {
                MessageBuilder.AppendLine(ex.Message);
                MessageBuilder.AppendLine("\r\n\r\n");
                MessageBuilder.AppendLine(ex.StackTrace);
                MessageBuilder.AppendLine("\r\n\r\n");

                ex = ex.InnerException;
            }

            String Message = MessageBuilder.ToString();

            if (File.Exists(ErrorPath))
            {
                File.Delete(ErrorPath);
            }

            File.Move(Filepath, ErrorPath);
            File.WriteAllText(ErrorPath + ".txt", Message);
            File.Delete(Filepath);

            System.Diagnostics.Debug.WriteLine(Message);
        }
    }
}

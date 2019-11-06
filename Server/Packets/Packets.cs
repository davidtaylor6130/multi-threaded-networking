using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace Packets
{
    sealed class AllowAllAssemblyVersionsDeserializationBinder : System.Runtime.Serialization.SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;

            String currentAssembly = Assembly.GetExecutingAssembly().FullName;

            // In this case we are always using the current assembly
            assemblyName = currentAssembly;

            // Get the type using the typeName and assemblyName
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}",
                typeName, assemblyName));

            return typeToDeserialize;
        }
    }

    public enum PacketType
    {
        Empty,
        ChatMessage,
        NickName,
        ServerLocation,
        DirectMessage,
        ServerCommand,
        ServerMessagePacket
    }

    public class Packet
    {
        public PacketType Type = PacketType.Empty;
    }

    [Serializable]
    public class ChatMessagePacket : Packet, ISerializable
    {
        public string message = string.Empty;

        public ChatMessagePacket(string message)
        {
            this.Type = PacketType.ChatMessage;
            this.message = message;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("message", message);
            info.AddValue("Type", Type);
        }

        public ChatMessagePacket(SerializationInfo info, StreamingContext context)
        {
            message = (string)info.GetValue("message", typeof(string));
            Type = (PacketType)info.GetValue("Type", typeof(PacketType));
        }
    }

    [Serializable]
    public class ServerMessagePacket : Packet, ISerializable
    {
        public string message = string.Empty;

        public ServerMessagePacket(string message)
        {
            this.Type = PacketType.ServerMessagePacket;
            this.message = message;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("message", message);
            info.AddValue("Type", Type);
        }

        public ServerMessagePacket(SerializationInfo info, StreamingContext context)
        {
            message = (string)info.GetValue("message", typeof(string));
            Type = (PacketType)info.GetValue("Type", typeof(PacketType));
        }
    }

    [Serializable]
    public class NickNamePacket : Packet, ISerializable
    {
        public string[] Name = new string[10];

        public NickNamePacket(string message, int arrayPosition)
        {
            this.Type = PacketType.NickName;
            this.Name[arrayPosition] = message;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Type", Type);
        }

        public NickNamePacket(SerializationInfo info, StreamingContext context)
        {
            Name = (string[])info.GetValue("Name", typeof(string[]));
            Type = (PacketType)info.GetValue("Type", typeof(PacketType));
        }
    }

    [Serializable]
    public class ServerLocationPacket : Packet, ISerializable
    {
        public string ServerName = string.Empty;
        public int serverLocation = -1;

        public ServerLocationPacket(string ServerName, int serverLocation)
        {
            this.Type = PacketType.ServerLocation;
            this.ServerName = ServerName;
            this.serverLocation = serverLocation;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ServerName", ServerName);
            info.AddValue("serverLocation", serverLocation);
            info.AddValue("Type", Type);
        }

        public ServerLocationPacket(SerializationInfo info, StreamingContext context)
        {
            ServerName = (string)info.GetValue("ServerName", typeof(string));
            serverLocation = (int)info.GetValue("serverLocation", typeof(int));
            Type = (PacketType)info.GetValue("Type", typeof(PacketType));
        }
    }

    [Serializable]
    public class DirectMessagePacket : Packet, ISerializable
    {
        public string Message = string.Empty;
        public string RecipentName = string.Empty;

        public DirectMessagePacket(string Message, string RecipentName)
        {
            this.Type = PacketType.DirectMessage;
            this.Message = Message;
            this.RecipentName = RecipentName;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Message", Message);
            info.AddValue("RecipentName", RecipentName);
            info.AddValue("Type", Type);
        }

        public DirectMessagePacket(SerializationInfo info, StreamingContext context)
        {
            Message = (string)info.GetValue("Message", typeof(string));
            RecipentName = (string)info.GetValue("RecipentName", typeof(string));
            Type = (PacketType)info.GetValue("Type", typeof(PacketType));
        }
    }

    [Serializable]
    public class ServerCommand : Packet, ISerializable
    {
        public string CommandToServer = string.Empty;

        public ServerCommand(string CommandToServer)
        {
            this.Type = PacketType.ChatMessage;
            this.CommandToServer = CommandToServer;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CommandToServer", CommandToServer);
            info.AddValue("Type", Type);
        }

        public ServerCommand(SerializationInfo info, StreamingContext context)
        {
            CommandToServer = (string)info.GetValue("CommandToServer", typeof(string));
            Type = (PacketType)info.GetValue("Type", typeof(PacketType));
        }
    }

}
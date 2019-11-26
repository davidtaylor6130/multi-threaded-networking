using System;
using System.Runtime.Serialization;
using System.Reflection;
using System.Net;
using Client;
using System.Runtime.Serialization;

namespace Packets
{
    public enum PacketType
    {
        Empty,
        ChatMessage,
        NickName,
        ServerLocation,
        DirectMessage,
        ServerCommand,
        ServerMessagePacket,
        EndPointPacket,
        GameConnectionPacket,
        GamePacket
    }

    [Serializable]
    public class Packet
    {
        public PacketType Type = PacketType.Empty;
    }

    [Serializable]
    public class ChatMessagePacket : Packet
    {
        public string message = string.Empty;

        public ChatMessagePacket(string message)
        {
            this.Type = PacketType.ChatMessage;
            this.message = message;
        }
    }

    [Serializable]
    public class ServerMessagePacket : Packet
    {
        public string message = string.Empty;

        public ServerMessagePacket(string message)
        {
            this.Type = PacketType.ServerMessagePacket;
            this.message = message;
        }
    }

    [Serializable]
    public class NickNamePacket : Packet
    {
        public string[] Name = new string[10];

        public NickNamePacket(string message, int arrayPosition)
        {
            this.Type = PacketType.NickName;
            this.Name[arrayPosition] = message;
        }
    }

    [Serializable]
    public class ServerLocationPacket : Packet
    {
        public string ServerName = string.Empty;
        public int serverLocation = -1;

        public ServerLocationPacket(string ServerName, int serverLocation)
        {
            this.Type = PacketType.ServerLocation;
            this.ServerName = ServerName;
            this.serverLocation = serverLocation;
        }
    }

    [Serializable]
    public class DirectMessagePacket : Packet
    {
        public string Message = string.Empty;
        public string RecipentName = string.Empty;

        public DirectMessagePacket(string Message, string RecipentName)
        {
            this.Type = PacketType.DirectMessage;
            this.Message = Message;
            this.RecipentName = RecipentName;
        }
    }

    [Serializable]
    public class ServerCommand : Packet
    {
        public string CommandToServer = string.Empty;

        public ServerCommand(string CommandToServer)
        {
            this.Type = PacketType.ChatMessage;
            this.CommandToServer = CommandToServer;
        }
    }

    [Serializable]
    public class EndPointPacket : Packet
    {
        public EndPoint endPoint;

        public EndPointPacket(EndPoint address)
        {
            this.Type = PacketType.EndPointPacket;
            this.endPoint = address;
        }
    }

    [Serializable]
    public class GameConnectionPacket : Packet
    {
        public bool startGameSession;

        public GameConnectionPacket(bool address)
        {
            this.Type = PacketType.GameConnectionPacket;
            this.startGameSession = address;
        }
    }

    [Serializable]
    public class GamePacket : Packet
    {
        public Checkers GameCheckers;

        public GamePacket(Checkers address)
        {
            this.Type = PacketType.GamePacket;
            this.GameCheckers = address;
        }
    }
}
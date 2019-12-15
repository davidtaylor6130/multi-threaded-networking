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
        GamePacket,
        TurnToggle,
        NameInUsePacket,
        RockPaperScissors,
        EndConnectionPacket
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
        public string From = "";
        public string To = "";

        public ChatMessagePacket(string message, string FrompassIn, string ToPassIn)
        {
            this.Type = PacketType.ChatMessage;
            this.message = message;
            this.From = FrompassIn;
            To = ToPassIn;
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
            this.Type = PacketType.ServerCommand;
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
        public string player1;
        public string player2;

        public GameConnectionPacket(bool address, string player1PassIn, string player2PassIn)
        {
            this.Type = PacketType.GameConnectionPacket;
            this.startGameSession = address;
            this.player1 = player1PassIn;
            this.player2 = player2PassIn;
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

    [Serializable]
    public class TurnToggle : Packet
    {
        public bool toggle = false;
        public string WhosTurn = "Player1";
        public TurnToggle(bool togglePassIn, string whosTurnPassIn)
        {
            this.Type = PacketType.TurnToggle;
            this.toggle = togglePassIn;
            this.WhosTurn = whosTurnPassIn;
        }
    }

    [Serializable]
    public class NameInUsePacket : Packet
    {
        public bool toggle = false;
        public NameInUsePacket(bool togglePassIn)
        {
            this.Type = PacketType.NameInUsePacket;
            toggle = togglePassIn;
        }
    }

    [Serializable]
    public class RockPaperScissors : Packet
    {
        public string Selection = "";

        public RockPaperScissors(string SelectionPassIn)
        {
            this.Type = PacketType.RockPaperScissors;
            Selection = SelectionPassIn;
        }
    }

    [Serializable]
    public class EndConnectionPacket : Packet
    {
        public string Selection = "";

        public EndConnectionPacket(string SelectionPassIn)
        {
            this.Type = PacketType.EndConnectionPacket;
            Selection = SelectionPassIn;
        }
    }

}
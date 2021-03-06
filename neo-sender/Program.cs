﻿using Neo.Cryptography;
using NeoLux;
using System;

namespace neo_sender
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length<5)
            {
                Console.WriteLine("neo-sender <Net> <PrivateKey> <DestAddress> <Symbol> <Amount>");
                return;
            }

            var net = (NeoAPI.Net) Enum.Parse(typeof(NeoAPI.Net), args[0], true);

            var keyStr = args[1];
            //fc1fa7c0d83426486373d9ce6eaca8adb506fc4ca25e89887c8eb5567f317a53"
            var outputAddress = args[2];
            //"AanTL6pTTEdnphXpyPMgb7PSE8ifSWpcXU"

            var symbol = args[3];   //"GAS"
            var amount = decimal.Parse(args[4]);

            var myKey = keyStr.Length == 52 ? KeyPair.FromWIF(keyStr) : new KeyPair(keyStr.HexToBytes());

            Console.WriteLine($"Sending {amount} {symbol} from {myKey.address} to {outputAddress}");

            var result = NeoAPI.SendAsset(net, outputAddress, symbol, amount, myKey);
            Console.WriteLine(result);
        }
    }
}

using System;
using System.Text;
using NSec.Cryptography;

namespace HazzaBot.Helper;

public class MessageValidator
{
    private PublicKey _publicKey;
    private SignatureAlgorithm _algorithm;

    public MessageValidator(string publicKey, SignatureAlgorithm algorithm = null)
    {
        _algorithm = algorithm ?? SignatureAlgorithm.Ed25519;
        _publicKey = PublicKey.Import(_algorithm, Convert.FromHexString(publicKey), KeyBlobFormat.RawPublicKey);
    }
    
    /// <summary>
    /// Checks the message from Discord is actually authentic
    /// </summary>
    /// <param name="message">The message to be checked, usually the request body</param>
    /// <param name="timestamp">Timestamp included in the header of the request</param>
    /// <param name="signature">Signature included in the header of the request</param>
    /// <returns>false - invalid message. true - valid message</returns>
    public bool Validate(string message, string timestamp, string signature)
    {
        var payload = Encoding.UTF8.GetBytes(timestamp + message);
        var sigAsHex = Convert.FromHexString(signature);

        return _algorithm.Verify(_publicKey, payload, sigAsHex);
    }
}
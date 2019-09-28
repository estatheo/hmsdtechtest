using System;
using hmsd.encryption.Interfaces;
using hmsd.encryption.Services;
using NUnit.Framework;

namespace Tests
{
    public class EncryptionServiceTests
    {
        private IEncryptionService _encryptionService;

        [SetUp]
        public void Setup()
        {

            _encryptionService = new EncryptionService();
        }

        [Test]
        public void EncryptionService_EncryptMessage_DecryptsToInitialMessage()
        {
            // arrange
            var startingText = "this is a test";
            
            // act
            var encryptedText = _encryptionService.Encrypt(startingText);
            var decryptedText = _encryptionService.Decrypt(encryptedText);

            // assert
            Assert.AreEqual(startingText, decryptedText);
        }

        [Test]
        public void EncryptionService_EncryptMessage_DecryptIsDifferentThanRandomMessage()
        {
            // arrange
            var startingText = "this is a test";
            var randomText = Guid.NewGuid().ToString();
            // act
            var encryptedText = _encryptionService.Encrypt(startingText);
            var decryptedText = _encryptionService.Decrypt(encryptedText);

            // assert
            Assert.AreNotEqual(randomText, decryptedText);
        }

        [Test]
        public void EncryptionService_EncryptMessage_EncryptIsDifferentThanstartingMessage()
        {
            // arrange
            var startingText = "this is a test";
            // act
            var encryptedText = _encryptionService.Encrypt(startingText);
            var decryptedText = _encryptionService.Decrypt(encryptedText);

            // assert
            Assert.AreNotEqual(startingText, encryptedText);
        }
    }
}
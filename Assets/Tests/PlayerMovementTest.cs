using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class PlayerMovementTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestTransformSimplePasses()
    {
        IPlayerMovementController playerMovementController = Substitute.For<IPlayerMovementController>();
    }
}
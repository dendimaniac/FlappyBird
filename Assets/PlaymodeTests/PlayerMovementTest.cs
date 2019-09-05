using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTest
{
    private GameObject player;
    private Rigidbody2D rb2D;
    private PlayerMovement playerMovement;
    private PlayerController playerController;

    [SetUp]
    public void SetUp()
    {
        GameObject player = new GameObject();
        Rigidbody2D rb2D = player.AddComponent<Rigidbody2D>();
        playerMovement = player.AddComponent<PlayerMovement>();
        playerMovement.JumpForce = 400f;
        playerMovement.MaxHeight = 4.5f;
        playerMovement.Position = new Vector2(0f, 0f);
        playerController = playerMovement.playerController;
    }

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator TestPlayerNeverGoOverMaxHeight()
    {
        yield return JumpAmountOfTimes(10);
        Assert.Greater(playerMovement.MaxHeight, playerMovement.Position.y);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        GameObject.Destroy(player);
    }

    private IEnumerator JumpAmountOfTimes(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForFixedUpdate();
            playerController.Jump();
        }
    }
}
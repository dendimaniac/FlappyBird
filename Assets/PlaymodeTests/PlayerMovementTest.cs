using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTest
{
    private GameObject player;
    private PlayerMovement playerMovement;
    private PlayerController playerController;

    [SetUp]
    public void SetUp()
    {
        player = new GameObject();

        player.AddComponent<Rigidbody2D>();
        playerMovement = player.AddComponent<PlayerMovement>();

//        playerMovement.JumpForce = 400f;
//        playerMovement.MaxHeight = 4.5f;
//        playerMovement.Position = new Vector2(0f, 0f);

        playerController = playerMovement.playerController;
    }

    [UnityTest]
    public IEnumerator PlayerNeverGoOverMaxHeight()
    {
        yield return JumpAmountOfTimes(10);
        Assert.GreaterOrEqual(playerMovement.MaxHeight, playerMovement.Position.y);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(player);
    }

    private IEnumerator JumpAmountOfTimes(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            playerController.Jump();
            yield return new WaitForFixedUpdate();
        }
    }
}
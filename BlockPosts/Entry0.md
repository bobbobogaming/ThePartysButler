# Entry 0: Roll a ball

For the beginning of the development of the roll a ball project, the unity tutorial was followed closely with very few modifications. But during the process, there were several obvious improvements that could be made to the program.

## Responsibilities of the player object and tracking pickups
The first thing, was that the player object had a lot of unnecessary responsibilities and that the win condition was something that needed to be manually input. In order to fix this the logic of tracking the progress towards the win condition was moved to a script that can be attached to a container holding the pickups.

```cs
void Start()
{
    oldChildCount = transform.childCount;
    totalChildCount = transform.childCount;
    winText.SetActive(false);
    UpdateUI();
}

...

private void UpdateUI()
{
    countText.text = "count: " + (totalChildCount - oldChildCount);
    if (oldChildCount == 0)
    {
        winText.SetActive(true);
        Invoke("ResetUI", 2.0f);
    }
}
```

As can be seen in the `Start()` method, in order to fix the problem of having to manually input the total amount of pickups, were fixed by just counting the amount of children of the `pickupContainer`. Doing it this way also makes it easy to use the same script for any future pickup types. as it should be more or less just to attach the script to a new container of another pickup type.

## Movement drag
Another thing was that it was kind of weird for the player to never come to a complete stop without hitting a wall. In order to make the players ball come to a slow stop, angular drag was attached to the player object, this was the rotation is slowed down over time and the player comes to a stop.

A side note in this adventure, was the interest in cubes with low ground friction. Ordinarily a cube will experience a large amount of friction, but by giving the cube a `physics material`, the friction can be lowered. This way a cube can be made to slide around like if it or the ground was made of ice.

## Level selection?
If a game is to have more then one "level," an idea is to create some form of level selection. This can be done in several different ways, but perhaps one of the more interesting methods, is to make the level selection sort of its own level. For this purpose a sort of `teleportation button` was created.

```cs
void OnTriggerStay(Collider other)
{
    if (loadBar.localScale.x >= 1)
    {
        if (levelPickupParent.childCount <= 0) return;
        var otherParent = other.gameObject.transform.parent;
        otherParent.position = location;
    }
    else
    {
        loadBar.localScale +=  new Vector3(((float)loadSpeed) / 100, 0, 0);
    }
}
```

It can be seen in this method that the button will expand a `loadBar` while a trigger activates it, and then after a while the button will set the parent of the triggers location to the target location. In order for this to work well with the player object, then the player object was given a trigger object as a child, this object is then slightly larger then the player to allow collision.
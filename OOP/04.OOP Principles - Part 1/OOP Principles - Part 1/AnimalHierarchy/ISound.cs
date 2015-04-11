namespace AnimalHierarchy
{
    interface ISound
    {
        // The method is not void intentionaly because of coupling and stuff.
        string ProduceSound();
    }
}

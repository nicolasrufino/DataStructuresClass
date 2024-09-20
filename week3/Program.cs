// third week

/*--------Create a simple function to find something in a List<int>---------*/
// Create a simple function to find something in a List<int>.
// Afterwards see if Visual Studio has a built in way to find it, make a separate function that uses it.

// For fun consider giving both a large data set to see which is faster.

public bool CustomSearch(List<int> list, int item)
{
    foreach (int element in list)
    {
        if (element == item)
        {
            return true;
        }
    }
    return false;
}

public bool BuiltInSearch(List<int> list, int thing)
{
    return list.Contains(thing);
} 

/*---------Create a simple function to find something in a List<string>----------*/
// Create a simple function to find something in a List<string>.
// Afterwards see if Visual Studio has a built in way to find it, make a separate function that uses it.

// For fun consider giving both a large data set to see which is faster.

public bool CustomSearch(List<string> list, string itemS)
{
    foreach (string element in list)
    {
        if (element == itemS)
        {
            return true;
        }
    }
    return false;
}

public bool BuiltInSearch(List<string> list, string thingS)
{
    return list.Contains(thingS);
}
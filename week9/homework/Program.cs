using System;
using System.Collections.Generic;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Rarity { get; set; }
    public int Strength { get; set; }

    public Item(int id, string name, string type, string rarity, int strength)
    {
        Id = id;
        Name = name;
        Type = type;
        Rarity = rarity;
        Strength = strength;
    }

    public override string ToString()
    {
        return $"Item(ID: {Id}, Name: '{Name}', Type: '{Type}', Rarity: '{Rarity}', Strength: {Strength})";
    }
}

public class TreeNode
{
    public Item Item { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }
    public int Height { get; set; }

    public TreeNode(Item item)
    {
        Item = item;
        Left = null;
        Right = null;
        Height = 1;
    }
}

public class BST
{
    private TreeNode root;

    public void Insert(Item item)
    {
        root = InsertRecursive(root, item);
    }

    private TreeNode InsertRecursive(TreeNode node, Item item)
    {
        if (node == null)
            return new TreeNode(item);

        if (item.Id < node.Item.Id)
            node.Left = InsertRecursive(node.Left, item);
        else
            node.Right = InsertRecursive(node.Right, item);

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        return Balance(node);
    }

    public void Delete(int id)
    {
        root = DeleteRecursive(root, id);
    }

    private TreeNode DeleteRecursive(TreeNode node, int id)
    {
        if (node == null) return node;

        if (id < node.Item.Id)
            node.Left = DeleteRecursive(node.Left, id);
        else if (id > node.Item.Id)
            node.Right = DeleteRecursive(node.Right, id);
        else
        {
            if (node.Left == null) return node.Right;
            else if (node.Right == null) return node.Left;

            TreeNode temp = MinValueNode(node.Right);
            node.Item = temp.Item;
            node.Right = DeleteRecursive(node.Right, temp.Item.Id);
        }

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        return Balance(node);
    }

    private TreeNode MinValueNode(TreeNode node)
    {
        TreeNode current = node;
        while (current.Left != null)
            current = current.Left;
        return current;
    }

    private TreeNode Balance(TreeNode node)
    {
        int balanceFactor = GetBalanceFactor(node);

        if (balanceFactor > 1)
        {
            if (GetBalanceFactor(node.Left) < 0)
                node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        if (balanceFactor < -1)
        {
            if (GetBalanceFactor(node.Right) > 0)
                node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    private int GetBalanceFactor(TreeNode node)
    {
        if (node == null) return 0;
        return GetHeight(node.Left) - GetHeight(node.Right);
    }

    private int GetHeight(TreeNode node)
    {
        return node == null ? 0 : node.Height;
    }

    private TreeNode RotateRight(TreeNode y)
    {
        TreeNode x = y.Left;
        TreeNode T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));
        x.Height = 1 + Math.Max(GetHeight(x.Left), GetHeight(x.Right));

        return x;
    }

    private TreeNode RotateLeft(TreeNode x)
    {
        TreeNode y = x.Right;
        TreeNode T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        x.Height = 1 + Math.Max(GetHeight(x.Left), GetHeight(x.Right));
        y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));

        return y;
    }

    public List<Item> InOrderTraversal()
    {
        List<Item> items = new List<Item>();
        InOrderRecursive(root, items);
        return items;
    }

    private void InOrderRecursive(TreeNode node, List<Item> items)
    {
        if (node != null)
        {
            InOrderRecursive(node.Left, items);
            items.Add(node.Item);
            InOrderRecursive(node.Right, items);
        }
    }

    public List<Item> GetItemsSortedByRarity()
    {
        List<Item> items = InOrderTraversal();
        items.Sort((x, y) =>
        {
            int rarityComparison = GetRarityValue(x.Rarity).CompareTo(GetRarityValue(y.Rarity));
            return rarityComparison != 0 ? rarityComparison : x.Id.CompareTo(y.Id);
        });
        return items;
    }

    private int GetRarityValue(string rarity)
    {
        switch (rarity)
        {
            case "Common": return 1;
            case "Rare": return 2;
            case "Legendary": return 3;
            default: return 0;
        }
    }

    public Item Search(int id)
    {
        return SearchRecursive(root, id);
    }

    private Item SearchRecursive(TreeNode node, int id)
    {
        if (node == null) return null;

        if (id == node.Item.Id)
            return node.Item;
        else if (id < node.Item.Id)
            return SearchRecursive(node.Left, id);
        else
            return SearchRecursive(node.Right, id);
    }

    public void OptimizeTree()
    {
        List<Item> items = InOrderTraversal();
        root = BuildBalancedTree(items, 0, items.Count - 1);
    }

    private TreeNode BuildBalancedTree(List<Item> items, int start, int end)
    {
        if (start > end) return null;

        int mid = (start + end) / 2;
        TreeNode node = new TreeNode(items[mid])
        {
            Left = BuildBalancedTree(items, start, mid - 1),
            Right = BuildBalancedTree(items, mid + 1, end)
        };

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        return node;
    }

    public void PrintTree(TreeNode node, string indent = "", bool last = true)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("R----");
                indent += "   ";
            }
            else
            {
                Console.Write("L----");
                indent += "|  ";
            }
            Console.WriteLine(node.Item);
            PrintTree(node.Left, indent, false);
            PrintTree(node.Right, indent, true);
        }
    }

    public TreeNode GetRoot()
    {
        return root;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BST inventory = new BST();

        inventory.Insert(new Item(50, "Sword of Truth", "Weapon", "Legendary", 100));
        inventory.Insert(new Item(25, "Potion of Healing", "Potion", "Common", 10));
        inventory.Insert(new Item(75, "Shield of Valor", "Armor", "Rare", 50));
        inventory.Insert(new Item(10, "Ring of Power", "Accessory", "Legendary", 200));
        inventory.Insert(new Item(30, "Dagger of Shadows", "Weapon", "Rare", 80));
        inventory.Insert(new Item(60, "Cloak of Invisibility", "Armor", "Legendary", 120));
        inventory.Insert(new Item(80, "Staff of Wisdom", "Weapon", "Common", 30));
        inventory.Insert(new Item(5, "Boots of Swiftness", "Accessory", "Rare", 40));

        Console.WriteLine("Initial Inventory (In-Order Traversal):");
        var items = inventory.InOrderTraversal();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nTree Structure:");
        inventory.PrintTree(inventory.GetRoot());


        Console.WriteLine("\nDeleting items with ID 10 and 75...");
        inventory.Delete(10);
        inventory.Delete(75);

        Console.WriteLine("\nInventory after deletions (In-Order Traversal):");
        items = inventory.InOrderTraversal();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }


        Console.WriteLine("\nOptimizing the tree...");
        inventory.OptimizeTree();

        Console.WriteLine("\nOptimized Inventory (In-Order Traversal):");
        items = inventory.InOrderTraversal();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }


        Console.WriteLine("\nSearching for item with ID 30...");
        Item searchedItem = inventory.Search(30);
        if (searchedItem != null)
        {
            Console.WriteLine($"Found: {searchedItem}");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }


        Console.WriteLine("\nItems sorted by rarity:");
        var sortedItems = inventory.GetItemsSortedByRarity();
        foreach (var item in sortedItems)
        {
            Console.WriteLine(item);
        }
    }
}
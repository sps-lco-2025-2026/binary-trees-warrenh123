namespace BinaryTreeTests;
using BinaryTreeLibrary;
using Microsoft.Testing.Platform.Requests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestExists_ReturnsTrue()
    {
        BinaryTree btree = new();
        btree.InsertIterative(10);
        btree.InsertIterative(7);
        btree.InsertIterative(12);

        bool result  = btree.Exists(12);

        Assert.IsTrue(result);
    }

    public void TestExists_ReturnsFalse()
    {
        BinaryTree btree = new();
        btree.InsertIterative(10);
        btree.InsertIterative(7);
        btree.InsertIterative(12);

        bool result  = btree.Exists(11);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void TestInsertIterative_ReturnTrue()
    {
        BinaryTree btree = new();
        List<int> valuesToTest = new List<int>{20, 10, 40, 50, 70};

        foreach(int i in valuesToTest)
        {
            btree.InsertIterative(i);
        }

        foreach(int i in valuesToTest)
        {
            Assert.IsTrue(btree.Exists(i));
        }
    }

    [TestMethod]
    public void TestSum_ReturnsCorrectTotal()
    {
        BinaryTree btree = new BinaryTree();
        btree.InsertIterative(10);
        btree.InsertIterative(20);  
        btree.InsertIterative(30);

        int total = btree.SumRecursive();

        Assert.AreEqual(60, total);
    }

    [TestMethod]
    public void TestToString_ReturnTrue()
    {
        BinaryTree btree = new BinaryTree();
        btree.InsertIterative(10);
        btree.InsertIterative(20);  
        btree.InsertIterative(30);

        string result = btree.ToString();

        Assert.AreEqual("10 20 30 ", result);
    }

    [TestMethod]
    public void TestDepth_ReturnsTrue()
    {
        BinaryTree btree = new BinaryTree();

        List<int> valuesToInsert = new List<int>{20, 10, 40, 30, 8, 4, 15};
        foreach(int i in valuesToInsert)
        {
            btree.InsertIterative(i);
        }

        int result = btree.Depth();

        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void TestBalanced_ReturnsTrue()
    {
        BinaryTree btree = new BinaryTree();

        List<int> valuesToInsert = new List<int>{20, 10, 40, 30, 8, 4, 15};
        foreach(int i in valuesToInsert)
        {
            btree.InsertIterative(i);
        }

        Assert.IsTrue(btree.IsBalanced());
    }

    [TestMethod]
    public void Delete_NoChildren_ReturnsTrue()
    {
        BinaryTree btree = new BinaryTree();
        btree.InsertIterative(10);
        btree.InsertIterative(5);
        btree.InsertIterative(15);
        
        btree.Delete(5);
        string result = btree.ToString().Trim();
        
        Assert.AreEqual("10 15", result);
    }   

    public void Delete_OneChild_ReturnsTrue()
    {
        
        BinaryTree btree = new BinaryTree();
        btree.InsertIterative(10);
        btree.InsertIterative(20);
        btree.InsertIterative(30);

        btree.Delete(20);
        string result = btree.ToString().Trim();

        Assert.AreEqual("10 30", result);
    }
    public void Delete_TwoChildren_ReturnsTrue()
    {
        BinaryTree btree = new BinaryTree();
        btree.InsertIterative(10);
        btree.InsertIterative(15);
        btree.InsertIterative(12);
        btree.InsertIterative(18);
        btree.InsertIterative(16); 

        string result = btree.ToString().Trim();

        Assert.AreEqual("10 12 16 18", result);
    }
}

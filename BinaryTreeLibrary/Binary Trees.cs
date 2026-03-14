using System.Text.Encodings.Web;
using System.Transactions;
using System.Xml;

namespace BinaryTreeLibrary;

internal class BinaryTreeNode
{
    internal int value;
    internal BinaryTreeNode left;
    internal BinaryTreeNode right;

    public BinaryTreeNode(int val)
    {
        value = val;
        left = null;
        right = null;
    }
}


public class BinaryTree
{
    internal BinaryTreeNode root;

    public BinaryTree()
    {
        root = null;
    }

    // Insert Method (I don't understand the recursive approach, wasn't my code)
    public void InsertRecursive(int v)
    {
        root = InsertRec(root, v);
    }

    private BinaryTreeNode InsertRec(BinaryTreeNode current, int v)
    {
        if(current == null)
        {
            return new BinaryTreeNode(v);
        }

        if(v < current.value)
        {
            current.left = InsertRec(current.left, v);
        }
        else if (v > current.value)
        {
            current.right = InsertRec(current.right,v);
        }

        return current;
    }


    public void InsertIterative(int v)
    {
        BinaryTreeNode newNode = new BinaryTreeNode(v);

        if (root == null)
        {
            root = newNode;
            return;
        }

        BinaryTreeNode current = root;

        while(true)
        {
            if(v < current.value)
            {
                if(current.left == null)
                {
                    current.left = newNode;
                    return;
                }

                current = current.left;
            }
            else
            {
                if(current.right == null)
                {
                    current.right = newNode;
                    return;
                }
                current = current.right;
            }
        }
    }

    // Exists Method
    public bool Exists(int v)
    {
        if(root == null)
        {
            return false;
        }

        BinaryTreeNode current = root;

        while(current != null)
        {
            if(current.value != v)
            {
                if(v < current.value)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }
            else
            {
                return true;
            }
        }
        return false;
    }


    // Sum Method
    public int SumRecursive()
    {
        return SumRec(root);
    }

    private int SumRec(BinaryTreeNode node)
    {
        if(node == null)
        {
            return 0;
        }

        return node.value + SumRec(node.left) + SumRec(node.right);
    }

    // ToString Method
    public override string ToString()
    {
        return ToStringRec(root);
    }

    private string ToStringRec(BinaryTreeNode node)
    {
        if(node == null)
        {
            return "";
        }

        string left = ToStringRec(node.left);
        string current = node.value.ToString() + " ";
        string right = ToStringRec(node.right);

        return left + current + right;
    }
    



}

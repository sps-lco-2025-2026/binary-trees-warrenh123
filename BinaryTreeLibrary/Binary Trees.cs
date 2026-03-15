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
            if(v ==  current.value) // Don't allow duplicates
            {
                return;
            }

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

    // Duplicate 
    // Went back and changed my Insert method so that there cannot be a duplicate in tree
    
    // Depth method
    public int Depth()
    {
        return DepthRec(root);
    }

    private int DepthRec(BinaryTreeNode node)
    {
        if(node == null)
        {
            return 0;
        }

        int leftDepth = DepthRec(node.left);
        int rightDepth = DepthRec(node.right);

        return Math.Max(leftDepth, rightDepth) + 1;
    }

    // Check Balanced method
    public bool IsBalanced()
    {
        return IsBalancedRec(root);
    }
    
    private bool IsBalancedRec(BinaryTreeNode node)
    {
        if(node == null)
        {
            return true;
        }

        int leftDepth = DepthRec(node.left);
        int rightDepth = DepthRec(node.right);

        return Math.Abs(leftDepth - rightDepth) <= 1 && IsBalancedRec(node.left) && IsBalancedRec(node.right);
    }

    // Deletion
    public void Delete(int v)
    {
        if (root == null) return;

        BinaryTreeNode current = root;
        BinaryTreeNode parent = null; 
        bool found = false;

        // Search node and parent
        while (current != null)
        {
            if (v == current.value)
            {
                found = true;
                break;
            }

            parent = current;

            if (v < current.value)
            {
                current = current.left;
            }   
            else
            {
                current = current.right;
            }
        }
        if (!found) return;

        //Node has no children
        if (current.left == null && current.right == null)
        {
            if (current == root)
            {
                root = null;
            }
            else if (parent.left == current)
            {
                parent.left = null;
            }
            else
            {
                parent.right = null;
            }
            return;
        }
        

        //Node has one child
        if(current.left == null || current.right == null)
        {
            BinaryTreeNode child = (current.left != null) ? current.left : current.right;

            if (current == root)
            {
                root = child; 
            }
            else if (parent.left == current)
            {
                parent.left = child;
            }
            else
            {
                parent.right = child;
            }
            return; 
        }

        //Node has two children
        else
        {
            BinaryTreeNode succParent = current;
            BinaryTreeNode succ = current.right;

            while (succ.left != null)
            {
                succParent = succ;
                succ = succ.left;
            }

            current.value = succ.value;

            if(succParent == current)
            {
                succParent.right = succ.right;
            }
            else
            {
                succParent.left = succ.right;
            }
            
        }
    }

}

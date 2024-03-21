
public static class Test
{
    public static void Main(string[] args)
    {
        var root = new BST(10);
        root.left = new BST(5);
        root.left.left = new BST(2);
        root.left.left.left = new BST(1);
        root.left.right = new BST(5);
        root.right = new BST(15);
        root.right.left = new BST(13);
        root.right.left.right = new BST(14);
        root.right.right = new BST(22);

        var actual = FindClosestValueInBst(root, 12);
    }

    public static int FindClosestValueInBst(BST tree, int target)
    {
        // Write your code here.

        return Iterative(tree, target);
    }

    /// <summary>
    /// Average : O(Log(N)) ST 
    /// Worst: O(N)ST when we have a tree with one branch nodes
    /// </summary>
    /// <param name="tree"></param>
    /// <param name="target"></param>
    /// <param name="closest"></param>
    /// <returns></returns>
    public static int Recursive(BST tree, int target, int closest)
    {

        double distance = Math.Sqrt(Math.Pow((double)(target - tree.value), 2));
        if (distance == 0) return target;
        double closestDistance = Math.Sqrt(Math.Pow((double)(target - closest), 2));
        if (distance < closestDistance) closest = tree.value;

        if (tree.value < target && tree.right != null)
        {
            return (Recursive(tree.right, target, closest));
        }

        if (tree.value > target && tree.left != null)
        {
            return (Recursive(tree.left, target, closest));
        }

        return closest;
    }

    /// <summary>
    /// Average : O(NlogN) T O(1) S  
    /// Worst: OO(N)T O(1) S when we have a tree with one branch nodes
    /// </summary>
    /// <param name="tree"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int Iterative(BST tree, int target)
    {

        int closest = tree.value;
        double closestDistance = Math.Sqrt(Math.Pow((double)(target - closest), 2));
        double distance = Math.Sqrt(Math.Pow((double)(target - tree.value), 2));

        BST currenBranche = tree;
        while (currenBranche != null)
        {
            distance = Math.Sqrt(Math.Pow((double)(target - currenBranche.value), 2));
            if (distance == 0) return target;
            closestDistance = Math.Sqrt(Math.Pow((double)(target - closest), 2));
            if (distance < closestDistance) closest = currenBranche.value;

            if (currenBranche.value < target && currenBranche.right != null)
            {
                currenBranche = currenBranche.right;
            }

            else if (currenBranche.value > target && currenBranche.left != null)
            {
                currenBranche = currenBranche.left;
            }
            else break;
        }

        return closest;
    }

}

public class BST
{
    public int value;
    public BST left;
    public BST right;

    public BST(int value)
    {
        this.value = value;
    }
}
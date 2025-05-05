namespace SistemaBiblioteca.Utils
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public TreeNode<T>? Root { get; private set; }

        public void Insert(T data)
        {
            Root = Insert(Root, data);
        }

        private TreeNode<T> Insert(TreeNode<T>? node, T data)
        {
            if (node == null) return new TreeNode<T>(data);
            int cmp = data.CompareTo(node.Data);
            if (cmp < 0) node.Left = Insert(node.Left, data);
            else if (cmp > 0) node.Right = Insert(node.Right, data);
            return node;
        }

        public bool Contains(T data)
        {
            return Contains(Root, data);
        }

        private bool Contains(TreeNode<T>? node, T data)
        {
            if (node == null) return false;
            int cmp = data.CompareTo(node.Data);
            if (cmp < 0) return Contains(node.Left, data);
            else if (cmp > 0) return Contains(node.Right, data);
            else return true;
        }

        public void InOrder(Action<T> visit)
        {
            InOrder(Root, visit);
        }

        private void InOrder(TreeNode<T>? node, Action<T> visit)
        {
            if (node == null) return;
            InOrder(node.Left, visit);
            visit(node.Data);
            InOrder(node.Right, visit);
        }
    }

}

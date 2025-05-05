namespace SistemaBiblioteca.Utils
{
    public class UserTree : BinarySearchTree<User>
    {
        public User? FindById(int id)
        {
            return FindById(Root, id);
        }

        private User? FindById(TreeNode<User>? node, int id)
        {
            if (node == null) return null;
            if (id < node.Data.Id) return FindById(node.Left, id);
            else if (id > node.Data.Id) return FindById(node.Right, id);
            else return node.Data;
        }

        public void RemoveUser(int id)
        {
            Root = Remove(Root, id);
        }

        private TreeNode<User>? Remove(TreeNode<User>? node, int id)
        {
            if (node == null) return null;
            if (id < node.Data.Id) node.Left = Remove(node.Left, id);
            else if (id > node.Data.Id) node.Right = Remove(node.Right, id);
            else
            {
                // Node with one child or no child
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                // Node with two children
                TreeNode<User> min = FindMin(node.Right);
                node.Data = min.Data;
                node.Right = Remove(node.Right, min.Data.Id);
            }
            return node;
        }

        private TreeNode<User> FindMin(TreeNode<User> node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }
    }

}

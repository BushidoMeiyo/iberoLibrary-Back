namespace SistemaBiblioteca.Utils
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public TreeNode<T>? Left { get; set; }
        public TreeNode<T>? Right { get; set; }

        public TreeNode(T data)
        {
            Data = data;
        }
    }
}

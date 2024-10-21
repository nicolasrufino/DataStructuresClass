namespace week9
{
    public class Hashy<K, V>
    {
        public class HashNode
        {
            public K key { get; set; }
            public V Value { get; set; }

            //next?
            public HashNode(K key, V value)
            {
                key = key;
                Value = value;
            }
        }
        public List<HashNode> NodesBucket { get; set; }
        public int Count { get; set; }
        public int Size { get; set; }
        public Hashy(int bucketSize)
        {
            Size = bucketSize;
            NodesBucket = new List<HashNode>(Size);//?
        }
        public int GetBucketIndex(K key)
        {
            int hashCode = key.GetHashCode();
            return Math.Abs(hashCode) % Size;
        }
    }
}

namespace AlgorithmAnalysisAssignmentFour
{
    internal class Program
    {
        static void Main()
        {
            string filePath = "output.txt";
            string compressedPath = "compressed.bin";
            string content = "this is a string";

            // Write string to file
            File.WriteAllText(filePath, content);

            // Read string back from file
            string text = File.ReadAllText(filePath);

            // Count frequencies
            Dictionary<char, int> frequencies = new Dictionary<char, int>();
            foreach (char c in text)
            {
                if (frequencies.ContainsKey(c))
                    frequencies[c]++;
                else
                    frequencies[c] = 1;
            }

            // Build Huffman tree
            Node root = BuildHuffmanTree(frequencies);

            // Generate codes
            Dictionary<char, string> codes = new Dictionary<char, string>();
            GenerateCodes(root, "", codes);

            // Print results
            Console.WriteLine("Huffman Codes:");
            foreach (var kv in codes)
            {
                string keyDisplay;
                if (kv.Key == '\r')
                    keyDisplay = "\\r";
                else if (kv.Key == '\n')
                    keyDisplay = "\\n";
                else if (kv.Key == '\t')
                    keyDisplay = "\\t";
                else if (kv.Key == ' ')
                    keyDisplay = "space";
                else
                    keyDisplay = kv.Key.ToString();

                Console.WriteLine(keyDisplay + "\t" + kv.Value);
            }

            // Encode text into bits
            string bitString = "";
            foreach (char c in text)
            {
                bitString += codes[c];
            }

            // Convert bit string into bytes
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < bitString.Length; i += 8)
            {
                string byteString = bitString.Substring(i, Math.Min(8, bitString.Length - i));
                if (byteString.Length < 8)
                {
                    // pad with zeros at the end
                    byteString = byteString.PadRight(8, '0');
                }
                bytes.Add(Convert.ToByte(byteString, 2));
            }

            // Write compressed data to binary file
            File.WriteAllBytes(compressedPath, bytes.ToArray());
            Console.WriteLine("Compressed data written to " + compressedPath);
        }

        static Node BuildHuffmanTree(Dictionary<char, int> frequencies)
        {
            List<Node> nodes = new List<Node>();
            foreach (var kv in frequencies)
            {
                nodes.Add(new Node(kv.Key, kv.Value));
            }

            while (nodes.Count > 1)
            {
                nodes.Sort(); // sort ascending by frequency

                Node left = nodes[0];
                Node right = nodes[1];

                Node parent = new Node(null, left.Frequency + right.Frequency);
                parent.Left = left;
                parent.Right = right;

                nodes.RemoveAt(0);
                nodes.RemoveAt(0);
                nodes.Add(parent);
            }

            return nodes[0];
        }

        static void GenerateCodes(Node node, string code, Dictionary<char, string> codes)
        {
            if (node == null)
                return;

            if (node.IsLeaf && node.Character.HasValue)
            {
                codes[node.Character.Value] = code.Length > 0 ? code : "0";
            }

            GenerateCodes(node.Left, code + "0", codes);
            GenerateCodes(node.Right, code + "1", codes);
        }
    }
}

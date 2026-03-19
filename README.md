# Huffman Compression (C#)

A program that uses Huffman encoding to compress text files based on character frequency.

## Overview

This project is a full implementation of the Huffman compression algorithm. It reads text from a file, calculates how often each character appears, and builds a Huffman tree from those frequencies. From there, it generates binary codes for each character and uses them to encode the text into a compressed format. The compressed data is then written to a binary file.

## Why I Built This

I built this project to get a better understanding of how data compression works and how algorithms can reduce file size efficiently. It also helped me practice working with trees, dictionaries, and file input/output in C#.

## Features

* Reads text from a file
* Calculates frequency of each character
* Builds a Huffman tree based on those frequencies
* Generates binary codes for each character
* Encodes the text into a compressed bit string
* Converts the bit string into bytes
* Writes compressed data to a binary file
* Prints Huffman codes to the console

## Tech Stack

* C#
* .NET
* Data Structures (Binary Trees, Dictionaries)

## How It Works

1. A string is written to a file and then read back into the program
2. The frequency of each character is calculated
3. A Huffman tree is built using those frequencies
4. Binary codes are generated for each character
5. The original text is encoded into a bit string using the codes
6. The bit string is converted into bytes
7. The compressed data is written to a binary file

## How to Run

1. Clone the repository
2. Open the project in Visual Studio
3. Run the program
4. View the Huffman codes printed in the console
5. Check the output binary file for the compressed result

## Example

Input text:
hello world

Huffman Codes:
h      1100
e      1101
l      10
o      01
space  1110
w      1111
r      000
d      001
Compressed data written to compressed.bin

## Future Improvements

* Add decompression functionality
* Support larger and more complex files
* Add a simple user interface

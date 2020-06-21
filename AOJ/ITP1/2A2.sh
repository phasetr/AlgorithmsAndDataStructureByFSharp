#!/bin/bash
chmod +x 2A2.hs
echo "RESULT a < b"
./2A2.hs < 2A1.txt

echo "RESULT a > b"
./2A2.hs < 2A2.txt

echo "RESULT a == b"
./2A2.hs < 2A3.txt

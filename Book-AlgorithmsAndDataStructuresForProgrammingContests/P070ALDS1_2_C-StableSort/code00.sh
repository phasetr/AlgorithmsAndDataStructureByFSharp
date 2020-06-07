#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o code00.out code00.cpp
echo "=================="
echo "SAMPLE 1"
echo "ANSWER"
echo "D2 C3 H4 S4 C9"
echo "Stable"
echo "D2 C3 S4 H4 C9"
echo "Not stable"
echo "=================="
echo "RESULT"
./code00.out < sample1.txt
echo "=================="

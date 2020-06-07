#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o code00.out code00.cpp
echo "=================="
echo "SAMPLE 1"
echo "ANSWER"
echo "35"
echo "5 4 2 1 19 9"
echo "=================="
echo "RESULT"
./code00.out < sample1.txt
echo "=================="

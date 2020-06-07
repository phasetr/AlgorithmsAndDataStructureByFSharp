#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o code00.out code00.cpp
echo "=================="
echo "SAMPLE 0"
echo "ANSWER: 89 71 71"
echo "=================="
echo "RESULT"
./code00.out < sample1.txt
echo "=================="

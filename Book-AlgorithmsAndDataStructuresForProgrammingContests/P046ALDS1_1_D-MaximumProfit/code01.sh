#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o code01.out code01.cpp
echo "=================="
echo "SAMPLE 1"
echo "ANSWER: 3"
./code01.out < sample1.txt
echo "=================="
echo "SAMPLE 2"
echo "ANSWER: -1"
./code01.out < sample2.txt
echo "=================="

#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o vectorIterator.out vectorIterator.cpp
echo "=================="
echo "SAMPLE 1"
echo "ANSWER"
echo "2014"
echo "3114"
echo "=================="
echo "RESULT"
./vectorIterator.out < vectorIterator.txt
echo "=================="

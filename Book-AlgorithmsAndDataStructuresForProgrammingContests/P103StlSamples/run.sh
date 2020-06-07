#!/bin/bash
g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o stack.out stack.cpp
echo "=================="
echo "stack"
./stack.out
echo "=================="

g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o queue.out queue.cpp
echo "=================="
echo "queue"
./queue.out
echo "=================="

g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o vector.out vector.cpp
echo "=================="
echo "vector"
./vector.out
echo "=================="

g++ -std=gnu++1y -g -O0 -I/opt/boost/gcc/include -L/opt/boost/gcc/lib -o list.out list.cpp
echo "=================="
echo "list"
./list.out
echo "=================="

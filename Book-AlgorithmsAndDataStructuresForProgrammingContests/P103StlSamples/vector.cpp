#include <iostream>
#include <vector>
using namespace std;

void print(vector<double> V) {
  for (int i = 0; i < V.size(); i++) {
    cout << V[i] << " ";
  }
  cout << endl;
}

int main() {
  vector<double> V;

  V.push_back(0.1);
  print(V);
  V.push_back(0.2);
  print(V);
  V.push_back(0.3);
  print(V);
  V[2] = 0.4;
  print(V);

  V.insert(V.begin() + 2, 0.8);
  print(V);

  V.erase(V.begin() + 1);
  print(V);

  V.push_back(0.9);
  print(V);
}
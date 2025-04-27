#include <iostream>

using namespace std;

int main()
{
    const int size = 5;
    bool arr[size]; 


    for (int i = 0; i < size; i++) {
        cout << "arr[" << i << "] = ";
        cin >> arr[i];
    }
    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;

    int temp; 


    for (int i = 0; i < size - 1; i++) {
        for (int j = 0; j < size - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }


    for (int i = 0; i < size; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;

    delete[] arr; 

    return 0;
}
void qSort(int A[], int nStart, int nEnd) {
    int L, R, c, X;
    if (nStart >= nEnd) return;
    L = nStart;
    R = nEnd;
    X = A[(L + R) / 2];
    while (L <= R) {
        while (A[L] < X) L++;
        while (A[R] > X) R--;
        if (L <= R) {

        }
    }
    qSort(A, nStart, R);
    qSort(A, nEnd, L);
}


import numpy as np
from PIL import Image
from numpy import asarray

def photoToRGB(photo):
    return asarray(photo)

def convertRGBToPhoto(numpydata, path):
    Image.fromarray(numpydata).save(path)

def modifySize(pho1, pho2, re):
    m = min(pho1.size[1], pho2.size[1])//re
    pho1 = pho1.resize((pho1.size[0]//re, m), Image.Resampling.LANCZOS)
    pho2 = pho2.resize((pho2.size[0]//re, m), Image.Resampling.LANCZOS)
    return (pho1, pho2)

foo = Image.open('p1.jpg')
foo1 = Image.open('p1.jpg')

foo, foo1 = modifySize(foo, foo1, 5)

photoData1 = photoToRGB(foo)
photoData2 = photoToRGB(foo1)

photo1Sequence = list()
photo2Sequence = list()

for array2D in photoData1:
    photo1Sequence.append(array2D)

for array2D in photoData2:
    photo2Sequence.append(array2D)

print(len(photo1Sequence))
print(len(photo2Sequence))


def price(x, y):
    return abs(int(x[0])- int(y[0])) + abs(int(x[1]) - int(y[1])) + abs(int(x[2]) - int(y[2]))

def get_minimum_penalty(x: list(), y: list(), pgap: int):
    i = 0
    j = 0

    m = len(x)
    n = len(y)

    dp = np.zeros([m+1, n+1], dtype=int)

    dp[0:(m+1), 0] = [i * pgap for i in range(m+1)]
    dp[0, 0:(n+1)] = [i * pgap for i in range(n+1)]

    i = 1
    while i <= m:
        j = 1
        while j <= n:
            if price(x[i-1], y[j-1]) == 0:
                dp[i][j] = dp[i - 1][j - 1]
            else:
                dp[i][j] = min(dp[i - 1][j - 1] + price(x[i-1], y[j-1]),
                               dp[i - 1][j] + pgap,
                               dp[i][j - 1] + pgap)
            j += 1
        i += 1

    c = dp[m][n]
    return c

def sequenceAlignment(rowCarpet1, rowCarpet2):
    gap_penalty = 250
    return get_minimum_penalty(rowCarpet1, rowCarpet2, gap_penalty)

def similarityCarpet(carpetData1, carpetData2):
    penalty = 0
    for i in range(len(carpetData1)):
        penalty += sequenceAlignment(carpetData1[i], carpetData2[i])
    
    return penalty

print(similarityCarpet(photo1Sequence, photo2Sequence))

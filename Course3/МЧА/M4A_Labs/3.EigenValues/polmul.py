import numpy as np
import sys

pol1 = []
pol2 = []

arg = sys.argv[1].split(' ')

firstPol = True
for x in arg:
    if x == '':
        continue
    if x == '|':
        firstPol = False
        continue
    if firstPol:
        pol1.append(float(x))
    else:
        pol2.append(float(x))

result = np.polymul(pol1, pol2)
print result

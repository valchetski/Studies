from secret import AsmuthBloomScheme
from random import randrange

secret = randrange(2 ** 256)
number = randrange(3, 20)
members = randrange(2, number - 1)

elements = AsmuthBloomScheme.share_secret(secret, number, members)
recovering_secret = AsmuthBloomScheme.restore_secret(elements, members)

print('Secret: ', secret)
print('Number: ', number)
print('Members: ', members)
print
print('Elements:')
i = 0
for i, (p, di, ki) in enumerate(elements):
    print(i+1, '. ', ki)
print('Restored secret: ', recovering_secret)

if secret == recovering_secret:
    print('Successfully')
else:
    print('Unsuccessful')

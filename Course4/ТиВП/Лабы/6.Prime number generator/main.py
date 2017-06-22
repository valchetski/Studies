import hashlib
import random
from operator import xor
from pip._vendor.requests.packages.urllib3.connectionpool import xrange
from pyprimes import isprime as is_prime


def sha(number):
    a = str(hex(number)).encode('utf-8')
    return int(hashlib.sha1(a).hexdigest(), 16)


def gen_big_prime_number(n, b, bits=160):
    while True:
        seed = g = q = 0

        while True:
            seed = random.randrange(start=2 ** 160)
            g = len(bin(seed))

            u = xor(sha(seed), sha((seed + 1) % (2 ** g)))
            q = u or 2 ** 159 or 1

            if is_prime(q):
                break

        counter = 0
        offset = 2

        while counter < 4096:
            v = []
            for k in xrange(0, n):
                v.append(sha((seed + offset + k) % (2 ** g)))

            w = v[0] + (v[-1] % (2 ** b)) * 2 ** (n * 160)
            for i, vk in enumerate(v[1:-1]):
                w += vk * 2 ** (160 * (i + 1))

            x = w + 2 ** (n * 160 + b)
            c = x % (2 * q)
            p = x - (c - 1)

            if not is_prime(p):
                counter += 1
                offset += n + 1
            else:
                return p, q, seed, counter


p, q, seed, counter = gen_big_prime_number(2, 10)

print ('SEED = ', seed)
print ('P = ', p)
print ('Q = ', q)

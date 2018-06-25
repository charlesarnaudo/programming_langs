#!/usr/bin/env python
# -*- coding: utf-8 -*-

import argparse
import re
from collections import OrderedDict


def get_num_repeating_letters(word):
    """Create dict from word, and loop through, assigning value to the key that
       is equal to the number of times the Key appears in word
    Arguments:
        word {string} -- Word to search for repeating letters
    """
    # letters are case insensitive for this problem
    word = str.lower(word)
    # Create dictionary from word
    dictionary = dict.fromkeys(word)

    for k in dictionary:
        dictionary[k] = word.count(k)

    # Get the key of the max value and return it
    max_key = max(dictionary, key=dictionary.get)
    return(dictionary[max_key])

if __name__ == '__main__':
    # Create an argparse object
    # Used to handle CLI arguments
    parser = argparse.ArgumentParser(
        description='Given text, find longest word with most repeating letters'
        )
    parser.add_argument('-f',
                        type=str,
                        metavar='',
                        help='input file',
                        required=True)
    args = parser.parse_args()

    with open(args.f, 'r') as file:
        # Use an OrderedDict to preserve order - first word that has the most
        # letters repeated wins
        dictionary = OrderedDict()

        for line in file:
            # Split line into words
            for word in line.split():
                # replace some puncuation with ''
                word = re.sub(r'[.?!",“”]', '', word)
                dictionary[word] = get_num_repeating_letters(word)

        # Find key with largest value in dictionary and print the key
        print(max(dictionary, key=dictionary.get))

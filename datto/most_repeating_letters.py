#!/usr/bin/env python
# -*- coding: utf-8 -*-

import argparse
import re
from collections import OrderedDict


def get_num_repeating_letters(word):
    """Loop through string and find the most times a char repeats itself
    Arguments:
        word {string} -- Word to search for repeating letters
    """
    # letters are case insensitive for this problem
    word = str.lower(word)

    count = 0
    for char in word:
        char_count = word.count(char)
        if  char_count > count:
            count = char_count
    return (count)

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

Reverser
========

Basic Code Exercise: Text File Reverser Console Application

Given I have a command line window open
And I type in a {input filename} “c:\{folder}\texttoreverse.txt” of saved text file that contains the {input text} “abcdef12345”
And I type in a {output filename} “c:\{folder}\textreversed.txt” of a text file that will be created
When press return
Then the command line reads “the input file: {input file} has been reversed and output to the file: {output filename} with the reversed content: {output text} “54321fedcba”
And the file {output filename} “c:\{folder}\textreversed.txt” is created
And the contents of the file contains {output text} “54321fedcba”
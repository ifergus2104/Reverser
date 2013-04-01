Reverser
========

Basic Code Exercise: Text File Reverser Console Application

- Given I have a command line window open
- And I type in a {input filename} of saved text file that contains the {input text}
- And I type in a {output filename}
- When press return
- Then the command line reads “the input file: {input file} has been reversed 
  and output to the file: {output filename} with the reversed content: {output text}"
- And the file {output filename} has been created
- And the contents of the file contains the reverse of the input as: {output text}

Specification By Example

- Given I have a command line window open
- And I type in “c:\{folder}\texttoreverse.txt” of saved text file that contains the text “abcdef12345”
- And I type in “c:\{folder}\textreversed.txt”
- When press return
- Then the command line reads “the input file: “c:\{folder}\texttoreverse.txt”  has been reversed 
  and output to the file: “c:\{folder}\textreversed.txt” with the reversed content: “54321fedcba”
- And the file “c:\{folder}\textreversed.txt” has been created
- And the contents of the file contains the reverse of the input as: “54321fedcba”

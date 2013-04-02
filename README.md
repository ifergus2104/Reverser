Reverser
========

Basic Code Exercise: Text File Reverser Console Application

Please provide in a text file a section of self crafted code (in a language of your choice) with associated unit tests that demonstrates a test driven approach to meeting the following acceptance criteria:

Given I have a command line window open
And I type in a {input filename} of saved text file that contains the {input text}
And I type in a {output filename}
When press return
Then the command line reads “the input file: {input filename} has been reversed 
  and output to the file: {output filename} with the reversed content: {output text}"
And the file {output filename} has been created
And the contents of the file contains the reverse of the input as: {output text}

Specification By Example

Given I have a command line window open
And I type in “{folder}\texttoreverse.txt” of saved text file that contains the text “abcdef12345”
And I type in “{folder}\textreversed.txt”
When press return
Then the command line reads “the input file: “{folder}\texttoreverse.txt”  has been reversed 
  and output to the file: “{folder}\textreversed.txt” with the reversed content: “54321fedcba”
And the file “{folder}\textreversed.txt” has been created
And the contents of the file contains the reverse of the input as: “54321fedcba”

Please note the following constraints:

Demonstrate a TDD approach.
Unit tests should not hit the file system although integration tests can be categorised and included

The code needs to adhere to the following criteria:
- Followed instructions
- Use of Test Driven Development
- Followed YAGNI
- Overall Readability

Score out of 5 for each criteria totalling a maximum score of 20

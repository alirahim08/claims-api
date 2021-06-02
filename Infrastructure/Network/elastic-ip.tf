resource "aws_eip" "eip_1a" {
  vpc = true
}

resource "aws_eip" "eip_1b" {
    vpc = true
}
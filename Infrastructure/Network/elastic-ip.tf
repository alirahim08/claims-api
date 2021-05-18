resource "aws_eip" "eip_2a" {
  vpc = aws_vpc.application_vpc.id
}

resource "aws_eip" "eip_2b" {
  vpc = aws_vpc.application_vpc.id
}
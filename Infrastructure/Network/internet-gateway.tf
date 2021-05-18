resource "aws_internet_gateway" "main_internet_gateway"{
  vpc_id = aws_vpc.application_vpc.id
  tags = {
    name = "${var.resource_prefix}-main-internet-gateway"
  }
}
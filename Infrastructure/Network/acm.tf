data "aws_acm_certificate" "issued" {
  domain   = "*.ivstechsolutions.com"
  statuses = ["ISSUED"]
}
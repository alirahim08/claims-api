locals {
  fqdn = "${var.resource_prefix}-api.${var.api_dns_zone}"
  tags = {
    Application = var.resource_prefix
    Environment = var.environment
  }
}
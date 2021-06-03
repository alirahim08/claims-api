data "aws_route53_zone" "hosted_zone" {
  name = "${var.api_dns_zone}."
  private_zone = false
}

resource "aws_route53_record" "alias_record" {
  name = local.fqdn
  type = "A"
  zone_id = data.aws_route53_zone.hosted_zone.id
  
  alias {
    evaluate_target_health = false
    name = aws_lb.api_load_balancer.dns_name
    zone_id = aws_lb.api_load_balancer.zone_id
  }
}

output "hosted_zone_name" {
  value = [
    data.aws_route53_zone.hosted_zone.name
  ]
}
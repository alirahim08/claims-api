resource "aws_s3_bucket" "api_lb_logs" {
  bucket = "${var.resource_prefix}-api-lb-logs"
  acl    = "private"
  tags = local.tags

  policy = <<POLICY
{
  "Version": "2012-10-17",
  "Id": "Policy",
  "Statement": [
    {
        "Effect": "Allow",
        "Principal": {
            "AWS": "arn:aws:iam::${data.aws_elb_service_account.account.id}:root"
        },
        "Action": "s3:PutObject",
        "Resource": "arn:aws:s3:::${var.resource_prefix}-api-lb-logs/AWSLogs/*"
    }
  ]
}
POLICY
}
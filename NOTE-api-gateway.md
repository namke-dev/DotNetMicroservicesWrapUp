# API Gateway
- routes requests to different microservices based on the request URL
- acting as a kind of “front door” to the microservices ecosystem
- Managing and routing requests from client to approriate micerservice/ backend servies within a system
- Can perform Loadbalancing

# I. Pupular provider
Here are some popular API gateway solutions:

## Amazon API Gateway
Use case: Ideal for large-scale applications and services running on AWS.
- A fully managed service that makes it easy for developers to create, publish, maintain, monitor, and secure APIs at any scale. 
- It supports RESTful APIs and WebSocket APIs for real-time two-way communication1.
## Kong Gateway
Use case: Suitable for microservices and cloud-native applications.
- Description: An open-source, cloud-native API gateway built on top of a lightweight proxy. 
- It offers features like authentication, traffic control, analytics, transformations, and logging2.
## Azure API Management
Use case: Best for applications running on Microsoft Azure.
- A fully managed service that enables organizations to publish, secure, transform, maintain, and monitor APIs. 
- It provides features like rate limiting, quotas, and policies1.
## Google Cloud API Gateway
Use case: Ideal for applications and services running on Google Cloud Platform.
- A fully managed gateway that helps developers build, deploy, and manage APIs on Google Cloud. 
- It supports both REST and gRPC APIs1.

# II. Feature
- Request Routing: Directs API requests to the appropriate backend services.
- Authentication and Authorization: Ensures that only authorized users can access the APIs, often integrating with identity providers like AWS IAM or OAuth.
- Rate Limiting and Throttling: Controls the number of requests a client can make to prevent abuse and ensure fair usage.
- Load Balancing: Distributes incoming API requests across multiple backend services to ensure reliability and performance.
- Caching: Stores responses to reduce the load on backend services and improve response times.
- Monitoring and Analytics: Tracks API usage and performance, often integrating with tools like AWS CloudWatch or Azure Monitor
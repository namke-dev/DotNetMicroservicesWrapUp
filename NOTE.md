# Monolithic and Microservices

## Monolithic
all services and data is process within a single application

### Pros
* Convinient for new project
* Fast Development at the begining
* Only need to deploy 1 app
* Easy to for end to end testing

### Cons
* hard to maintain due to complexity
* rolling back is all or nothing
* NO isolation from failures
* hard to adopt new tech
* hard to scale

## Microservices
Structure app as a collection of services, each of them can be deploy independently, and has thier own DB, There a dev team behind services

### Pros
* autonomy team, can work parallel
* simple code base
* fast deploy and rollback
* easy to adopt new tech
* easy to scale
* easy for feature/function test
* isolation form failures

### Cons
* Hard to choose right set of tech
* Add complexity of distributed systems
* Hard to debug between services (E2E testing)

## Key characteristics and principles
### 1. Services independence
- the unit has it's own business responsibility/ functionality
- has it own database, communicate mechanism
-> enable team to work parallel without interfering with each others
### 2. Simple comminication
- sync/ async protocol
-> enable service to be deploys and scale independently
### 3. Scalability and Resilience
- allow horizontal scaling, the service can bbe replicated across the multiple server (help handle increase load)
- Improve failure isolation -> high availability
### 4. Continuous Delivery and DevOps
- enable teams to independently develop, test, deploy 

# Implement Microservices

## 1. API Gataway
- manage and route request to the right service

## 2. Service Communication
### Synchronous
- Use REST or service communication
### Asynchronous 
- RabitMQ/ Apache Kafkka

## 3. Containerization
- Docker: ensures the consistent enviroment aross all server
- Kubernetes: allow auto scaling, self-healing, streamlined

## 4. others
- Observability:
    - Priority: Observability should be a key focus.
    - Components: Integrate logging, monitoring, and tracing.
    - Purpose: To gain visibility into system performance and quickly diagnose issues.
    - Tools: Use tools like the ELK stack (Elasticsearch, Logstash, Kibana), Prometheus, and Jaeger.
- Security:
    - Multiple Levels: Security must be enforced at various levels.
    - API Security: Use OAuth2 or JWT (JSON Web Tokens) for securing APIs.
    - Service-to-Service Communication: Secure communication between services using mTLS (mutual Transport Layer Security).
    - Data Encryption: Encrypt data both in transit (while it’s being transferred) and at rest (when it’s stored).
using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using FoodDeliveryService.Messaging;
using OrderService.Proxy;
using RestaurantService.Domain.Entities;
using RestaurantService.Domain.Repositories;
using OrderService.DTO.Messages;

namespace RestaurantService.Domain.UnitTests
{
    public class RestaurantServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public async Task Given_PendingTicket_When_TicketAccepted_Then_TicketStatusIsUpdated_And_OrderServiceIsNotified()
        //{
        //    //Given
        //    var ticketId = Guid.NewGuid();

        //    Mock<IRestaurantServiceRepository> mockRepository = new Mock<IRestaurantServiceRepository>();
        //    mockRepository.Setup(repo => repo.GetTicketById(It.IsAny<Guid>())).ReturnsAsync(new Ticket
        //    {
        //        OrderId = ticketId,
        //        RestaurantId = Guid.NewGuid(),
        //        TicketStatus = TicketStatus.AcceptancePending
        //    });

        //    var mockOrderServiceMessageBrokerClient = new Mock<IMessageBrokerClient>();
        //    mockOrderServiceMessageBrokerClient.Setup(client => client.SendMessageAsync(It.Is<MessageEnvelope>(messageEnvelope =>
        //       messageEnvelope.Type == OrderServiceMessageEnvelopeTypes.TicketAcceptedEvent
        //    && messageEnvelope.MessageId == ticketId)));

        //    var mockOrderServiceMessageBrokerClientFactory = new Mock<IMessageBrokerClientFactory>();
        //    mockOrderServiceMessageBrokerClientFactory
        //        .Setup(factory => factory.CreateClient(It.IsAny<MessageBrokerClientOptions>()))
        //        .Returns(mockOrderServiceMessageBrokerClient.Object);

        //    var mockOrderServiceProxyConfig = new Mock<IOrderServiceProxyConfiguration>();

        //    var orderServiceProxy = new OrderServiceProxy(mockOrderServiceMessageBrokerClientFactory.Object, mockOrderServiceProxyConfig.Object);

        //    var orderService = new RestaurantService.Domain.Services.RestaurantService(mockRepository.Object, orderServiceProxy);
            
        //    //When
        //    var serviceOperationResult = await orderService.AcceptTicket(ticketId);

        //    //Then
        //    mockRepository.Verify(repo => repo.GetTicketById(ticketId), Times.Once);
        //    mockOrderServiceMessageBrokerClient.Verify(client => client.SendMessageAsync(It.Is<MessageEnvelope>(messageEnvelope => 
        //       messageEnvelope.Type == OrderServiceMessageEnvelopeTypes.TicketAcceptedEvent
        //    && messageEnvelope.MessageId == ticketId)), Times.AtLeastOnce);
        //    Assert.IsTrue(serviceOperationResult.IsSuccess);

        //}
    }
}
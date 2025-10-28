using AutoMapper;
using TodoApp.Application.Auth.Commands;
using TodoApp.Application.Dtos;
using TodoApp.Application.Todos.Commands;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, AuthResponseDto>();

        CreateMap<TodoItem, TodoItemDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
        CreateMap<CreateTodoCommand, TodoItem>();
        CreateMap<UpdateTodoCommand, TodoItem>();
        
        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.TodoCount, opt => opt.MapFrom(src => src.TodoItems.Count));
        CreateMap<CreateCategoryCommand, Category>();
    }
}
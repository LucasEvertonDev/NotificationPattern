﻿using Architecture.Application.Core.Notifications;
using Architecture.Application.Core.Notifications.Context;
using Architecture.Application.Core.Notifications.Notifiable;
using Architecture.Application.Core.Structure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Principal;

namespace Architecture.Application.UseCases.UseCases.Base;

public abstract class BaseUseCase<TParam, TRetorno>
{
    private readonly IUnitOfWork _unitOfWork;
    protected readonly IIdentity _identity;
    protected readonly NotificationContext _notificationContext;

    public BaseUseCase(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetService<IUnitOfWork>();
        _identity = serviceProvider.GetService<IHttpContextAccessor>()?.HttpContext?.User?.Identity;
        _notificationContext = serviceProvider.GetService<NotificationContext>();
    }

    public abstract Task<TRetorno> ExecuteAsync(TParam param);

    protected virtual Task OnSucess()
    {
        return Task.CompletedTask;
    }

    protected async virtual Task OnError(Exception exception)
    {
        await _unitOfWork.RollbackAsync();
        throw exception;
    }

    protected async Task<TRetorno> OnTransactionAsync(Func<Task<TRetorno>> func)
    {
        try
        {
            TRetorno retorno = await func();
            await _unitOfWork.CommitAsync();
            return retorno;
        }
        catch (Exception exception)
        {
            await OnError(exception);
            return default;
        }
        finally
        {
            await OnSucess();
        }
    }

    /// <summary>
    /// Instancia classe para trabalhar com notificationPattern
    /// </summary>
    /// <typeparam name="TNotifiable"></typeparam>
    /// <returns></returns>
    protected TNotifiable Inject<TNotifiable>() where TNotifiable : Notifiable
    {
        var entity = Activator.CreateInstance<TNotifiable>();
        entity.SetNotificationContext(_notificationContext);
        return entity;
    }


    /// <summary>
    /// Instancia classe para trabalhar com notificationPattern
    /// </summary>
    /// <typeparam name="TNotifiable"></typeparam>
    /// <returns></returns>
    protected TNotifiable InjectVO<TNotifiable>() where TNotifiable : NotifiableValueObject
    {
        var entity = Activator.CreateInstance<TNotifiable>();
        entity.SetNotificationContext(_notificationContext);
        return entity;
    }

    public void RegisterNotification()
    {

    }
}

public abstract class BaseUseCase<TParam>
{
    private readonly IUnitOfWork _unitOfWork;
    protected readonly IIdentity _identity;

    public BaseUseCase(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetService<IUnitOfWork>();
        _identity = serviceProvider.GetService<IHttpContextAccessor>()?.HttpContext?.User?.Identity;
    }

    public abstract Task ExecuteAsync(TParam param);

    protected virtual Task OnSucess()
    {
        return Task.CompletedTask;
    }

    protected async virtual Task OnError(Exception exception)
    {
        await _unitOfWork.RollbackAsync();
        throw exception;
    }

    public async Task OnTransactionAsync(Func<Task> func)
    {
        try
        {
            await func();
            await _unitOfWork.CommitAsync();
        }
        catch (Exception exception)
        {
            await OnError(exception);
        }
        finally
        {
            await OnSucess();
        }
    }

    public async Task<TRetorno> OnTransactionAsync<TRetorno>(Func<Task<TRetorno>> func)
    {
        try
        {
            TRetorno retorno = await func();
            await _unitOfWork.CommitAsync();
            return retorno;
        }
        catch (Exception exception)
        {
            await OnError(exception);
            return default;
        }
        finally
        {
            await OnSucess();
        }
    }
}

public abstract class BaseUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    protected readonly IIdentity _identity;

    public BaseUseCase(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetService<IUnitOfWork>();
        _identity = serviceProvider.GetService<IHttpContextAccessor>().HttpContext.User?.Identity;
    }

    public abstract Task ExecuteAsync();

    protected virtual Task OnSucess()
    {
        return Task.CompletedTask;
    }

    protected async virtual Task OnError(Exception exception)
    {
        await _unitOfWork.RollbackAsync();
        throw exception;
    }

    public async Task OnTransactionAsync(Func<Task> func)
    {
        try
        {
            await func();
            await _unitOfWork.CommitAsync();
        }
        catch (Exception exception)
        {
            await OnError(exception);
        }
        finally
        {
            await OnSucess();
        }
    }

    public async Task<TRetorno> OnTransactionAsync<TRetorno>(Func<Task<TRetorno>> func)
    {
        try
        {
            TRetorno retorno = await func();
            await _unitOfWork.CommitAsync();
            return retorno;
        }
        catch (Exception exception)
        {
            await OnError(exception);
            return default;
        }
        finally
        {
            await OnSucess();
        }
    }
}